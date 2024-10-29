from abc import ABC, abstractmethod

# singleton (manager)
class CarProductionManager:
    instance = None

    def __new__(cls):
        if cls.instance is None:
            cls.instance = super(CarProductionManager, cls).__new__(cls)
            cls.instance.name = "Chief Production Manager"
        return cls.instance

# factory method (car types)
class Car(ABC):
    @abstractmethod
    def manufacture(self):
        pass

class SUV(Car):
    def manufacture(self):
        return "Manufacturing an SUV"

class Sedan(Car):
    def manufacture(self):
        return "Manufacturing a Sedan"

class Truck(Car):
    def manufacture(self):
        return "Manufacturing a Truck"

class CarFactory:
    @staticmethod
    def get_car(car_type):
        if car_type == "suv":
            return SUV()
        elif car_type == "sedan":
            return Sedan()
        elif car_type == "truck":
            return Truck()
        else:
            return None

# abstract factory (car engine and tires)
class Engine(ABC):
    @abstractmethod
    def assemble(self):
        pass

class Tire(ABC):
    @abstractmethod
    def produce(self):
        pass

class LuxuryEngine(Engine):
    def assemble(self):
        return "Assembling a luxury engine"

class EconomyEngine(Engine):
    def assemble(self):
        return "Assembling an economy engine"

class LuxuryTire(Tire):
    def produce(self):
        return "Producing luxury tires"

class EconomyTire(Tire):
    def produce(self):
        return "Producing economy tires"

class CarPartsFactory(ABC):
    @abstractmethod
    def create_engine(self):
        pass

    @abstractmethod
    def create_tires(self):
        pass

class LuxuryCarPartsFactory(CarPartsFactory):
    def create_engine(self):
        return LuxuryEngine()

    def create_tires(self):
        return LuxuryTire()

class EconomyCarPartsFactory(CarPartsFactory):
    def create_engine(self):
        return EconomyEngine()

    def create_tires(self):
        return EconomyTire()

# builder (car parts)
class CarModel:
    def __init__(self):
        self.doors = None
        self.engine = None
        self.color = None

    def __str__(self):
        return f"Car with {self.doors} doors, {self.engine} engine, and {self.color} color."

class CarBuilder:
    def __init__(self):
        self.car = CarModel()

    def build_doors(self, doors):
        self.car.doors = doors
        return self

    def build_engine(self, engine_type):
        self.car.engine = engine_type
        return self

    def paint(self, color):
        self.car.color = color
        return self

    def build(self):
        return self.car


if __name__ == "__main__":
    
    # singleton
    manager1 = CarProductionManager()
    manager2 = CarProductionManager()
    print(manager1 is manager2)
    print(manager1.name)

    # factory method
    car_factory = CarFactory()
    sedan = car_factory.get_car("sedan")
    print(sedan.manufacture())

    # abstract factory
    luxury_factory = LuxuryCarPartsFactory()
    luxury_engine = luxury_factory.create_engine()
    luxury_tires = luxury_factory.create_tires()
    print(luxury_engine.assemble())
    print(luxury_tires.produce())

    # builder
    builder = CarBuilder()
    custom_car = builder.build_doors(4).build_engine("V8").paint("yellow").build()
    print(custom_car)