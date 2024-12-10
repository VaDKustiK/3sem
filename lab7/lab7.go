package main

import (
	"fmt"
	"log"

	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

type Category struct {
	ID       uint `gorm:"primaryKey"`
	Name     string
	Products []Product `gorm:"foreignKey:CategoryID"`
}

type Product struct {
	ID         uint `gorm:"primaryKey"`
	Name       string
	Price      float64
	CategoryID uint
}

func main() {
	dsn := "host=localhost user=postgres password=securepass321 dbname=lab7_db port=5432 sslmode=disable"

	db, err := gorm.Open(postgres.Open(dsn), &gorm.Config{})
	if err != nil {
		log.Fatalf("failed to connect to the database: %v", err)
	}

	db.AutoMigrate(&Category{}, &Product{})

	category := Category{Name: "Luxury Cars"}
	if err := db.Create(&category).Error; err != nil {
		log.Fatalf("failed to create category: %v", err)
	}

	product1 := Product{Name: "Ferrari", Price: 250000, CategoryID: category.ID}
	product2 := Product{Name: "Lamborghini", Price: 300000, CategoryID: category.ID}
	db.Create(&product1)
	db.Create(&product2)

	var products []Product
	if err := db.Where("category_id = ?", category.ID).Find(&products).Error; err != nil {
		log.Fatalf("failed to read products: %v", err)
	}
	fmt.Println("Products in category:", category.Name)
	for _, p := range products {
		fmt.Printf(" - %s: $%.2f\n", p.Name, p.Price)
	}

	newCategory := Category{Name: "Sports Cars"}
	db.Create(&newCategory)
	db.Model(&product1).Update("CategoryID", newCategory.ID)

	if err := db.Where("category_id = ?", category.ID).Delete(&Product{}).Error; err != nil {
		log.Fatalf("failed to delete products in category: %v", err)
	}

	if err := db.Delete(&category).Error; err != nil {
		log.Fatalf("failed to delete category: %v", err)
	}
}
