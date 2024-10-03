// using System;

// public abstract class GameObject // основной класс
// {
//     private int id;
//     private string name;
//     private int x, y;

//     public GameObject(int id, string name, int x, int y)
//     {
//         this.id = id;
//         this.name = name;
//         this.x = x;
//         this.y = y;
//     }

//     public int GetId() { return id; }
//     public string GetName() { return name; }
//     public int GetX() { return x; }
//     public int GetY() { return y; }
    
//     public void SetPosition(int x, int y)
//     {
//         this.x = x;
//         this.y = y;
//     }
// }

// public abstract class Unit : GameObject // класс для юнитов (наследование от Gameobject)
// {
//     private float hp;  // количество хп

//     public Unit(int id, string name, int x, int y, float hp) : base(id, name, x, y)
//     {
//         this.hp = hp;
//     }

//     public bool IsAlive() { return hp > 0; }

//     public void ReceiveDamage(float damage) // метод для получения урона
//     {
//         hp -= damage;
//         if (hp < 0) hp = 0; // чтобы не было отрицательного значения хп
//     }

//     public float GetHp() { return hp; } // текущее значение хп
// }

// public class Archer : Unit // класс для юнита лучника
// {
//     public Archer(int id, string name, int x, int y, float hp) : base(id, name, x, y, hp) { }

//     public void Attack(Unit unit) // метод атаки лучника
//     {
//         Console.WriteLine($"{GetName()} attacks {unit.GetName()}");
//         unit.ReceiveDamage(10);  // потерял 10 хп
//     }

//     public void Move(int newX, int newY) // перемещение
//     {
//         SetPosition(newX, newY);
//         Console.WriteLine($"{GetName()} moves on ({newX}, {newY})");
//     }
// }

// public abstract class Building : GameObject // класс для атакующих построек
// {
//     private bool isBuilt;

//     public Building(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y)
//     {
//         this.isBuilt = isBuilt; // состояние постройки
//     }

//     public bool IsBuilt() { return isBuilt; }
// }

// public class Fort : Building
// {
//     public Fort(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y, isBuilt) { }

//     public void Attack(Unit unit)
//     {
//         Console.WriteLine($"{GetName()} attacks {unit.GetName()}");
//         unit.ReceiveDamage(20); // наносим 20 хп
//     }
// }

// public class MobileHouse : Building // класс для передвижных построек
// {
//     public MobileHouse(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y, isBuilt) { }

//     public void Move(int newX, int newY)
//     {
//         SetPosition(newX, newY);
//         Console.WriteLine($"{GetName()} moves on ({newX}, {newY})");
//     }
// }

// //test
// class Program {
//     static void Main(string[] args) {
//         Archer archer = new Archer(1, "archer", 0, 0, 50);
//         Fort fort = new Fort(2, "fort", 10, 10, true);
//         MobileHouse mobilehouse = new MobileHouse(3, "mobile house", 5, 5, true);

//         archer.Move(3, 1);
//         fort.Attack(archer);
//         Console.WriteLine($"archer's hp is {archer.GetHp()}");
//         mobilehouse.Move(5, 5);
//     }
// }