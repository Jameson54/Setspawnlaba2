using System;
using System.Collections.Generic;

namespace Animal
{
  public class Animal
  {
    public string name;
    public int age;
    public string habitat;
    public string foodType;

    public Animal(string animalName, int animalAge, string animalHabitat, string animalFoodType)
    {
      name = animalName;
      age = animalAge;
      habitat = animalHabitat;
      foodType = animalFoodType;
    }

    public virtual string GetInfo()
    {
      return "Name: " + name + ", Age: " + age + ", Habitat: " + habitat + ", Diet: " + foodType;
    }
  }

  public class Mammal : Animal
  {
    public bool hasFur;

    public Mammal(string mammalName, int mammalAge, string mammalHabitat, string mammalFoodType, bool mammalHasFur) 
      : base(mammalName, mammalAge, mammalHabitat, mammalFoodType)
    {
      hasFur = mammalHasFur;
    }

    public override string GetInfo()
    {
      string furStatus;

      if (hasFur == true)
      {
        furStatus = "Yes";
      }
      else
      {
        furStatus = "No";
      }

      return base.GetInfo() + ", Type: Mammal, Fur: " + furStatus;
    }
  }

  public class Bird : Animal
  {
    public double wingSpan;

    public Bird(string birdName, int birdAge, string birdHabitat, string birdFoodType, double birdWingSpan) 
      : base(birdName, birdAge, birdHabitat, birdFoodType)
    {
      wingSpan = birdWingSpan;
    }

    public override string GetInfo()
    {
      return base.GetInfo() + ", Type: Bird, Wingspan: " + wingSpan + " m";
    }
  }

  public class Fish : Animal
  {
    public string waterType;

    public Fish(string fishName, int fishAge, string fishHabitat, string fishFoodType, string fishWaterType) 
      : base(fishName, fishAge, fishHabitat, fishFoodType)
    {
      waterType = fishWaterType;
    }

    public override string GetInfo()
    {
      return base.GetInfo() + ", Type: Fish, Water: " + waterType;
    }
  }

  public class Reptile : Animal
  {
    public bool isVenomous;

    public Reptile(string reptileName, int reptileAge, string reptileHabitat, string reptileFoodType, bool reptileIsVenomous) 
      : base(reptileName, reptileAge, reptileHabitat, reptileFoodType)
    {
      isVenomous = reptileIsVenomous;
    }

    public override string GetInfo()
    {
      string venomStatus;

      if (isVenomous == true)
      {
        venomStatus = "Yes";
      }
      else
      {
        venomStatus = "No";
      }

      return base.GetInfo() + ", Type: Reptile, Venomous: " + venomStatus;
    }
  }

  public class Amphibian : Animal
  {
    public string skinMoisture;

    public Amphibian(string amphibianName, int amphibianAge, string amphibianHabitat, string amphibianFoodType, string amphibianSkinMoisture) 
      : base(amphibianName, amphibianAge, amphibianHabitat, amphibianFoodType)
    {
      skinMoisture = amphibianSkinMoisture;
    }

    public override string GetInfo()
    {
      return base.GetInfo() + ", Type: Amphibian, Skin Moisture: " + skinMoisture;
    }
  }

  public class AnimalManager
  {
    private static AnimalManager instance;
    private List<Animal> animals;

    private AnimalManager()
    {
      animals = new List<Animal>();
    }

    public static AnimalManager Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new AnimalManager();
        }

        return instance;
      }
    }

    public void AddAnimal(Animal newAnimal)
    {
      if (newAnimal == null)
      {
        Console.WriteLine("Cannot add null animal.");

        return;
      }

      animals.Add(newAnimal);
      Console.WriteLine("Animal '" + newAnimal.name + "' added!");
    }

    public void DisplayAllAnimals()
    {
      int displayNumber;
      int animalCount;
      int oneStep;

      oneStep = 1;

      if (animals.Count == 0)
      {
        Console.WriteLine("The animal list is empty.");

        return;
      }

      Console.WriteLine("");
      Console.WriteLine("=== ALL ANIMALS ===");

      animalCount = animals.Count;

      for (int animalIndex = 0; animalIndex < animalCount; ++animalIndex)
      {
        displayNumber = animalIndex + oneStep;

        Console.WriteLine(displayNumber + ". " + animals[animalIndex].GetInfo());
      }
    }

    public void DisplayAnimalByName(string searchName)
    {
      int animalCount;

      if (string.IsNullOrWhiteSpace(searchName))
      {
        Console.WriteLine("Name cannot be empty.");

        return;
      }

      animalCount = animals.Count;

      for (int animalIndex = 0; animalIndex < animalCount; ++animalIndex)
      {
        if (animals[animalIndex].name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
        {
          Console.WriteLine(animals[animalIndex].GetInfo());

          return;
        }
      }

      Console.WriteLine("Animal with name '" + searchName + "' was not found.");
    }
  }

  public static class Program
  {
    private static void Main()
    {
      AnimalManager manager = AnimalManager.Instance;

      string choice;
      string name;

      manager.AddAnimal(new Mammal("Leo", 5, "Savanna", "Carnivore", true));
      manager.AddAnimal(new Bird("Aquila", 3, "Mountains", "Carnivore", 2.5));
      manager.AddAnimal(new Fish("Goldie", 1, "Aquarium", "Herbivore", "Fresh"));
      manager.AddAnimal(new Reptile("Slither", 2, "Desert", "Carnivore", true));
      manager.AddAnimal(new Amphibian("Jumpo", 1, "Pond", "Insectivore", "Moist"));

      while (true)
      {
        Console.WriteLine("");
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1. Display all animals");
        Console.WriteLine("2. Find animal by name");
        Console.WriteLine("3. Exit");
        Console.Write("Choose option: ");

        choice = Console.ReadLine();
        
        if (choice == "1")
        {
          manager.DisplayAllAnimals();
        }
        else if (choice == "2")
        {
          Console.Write("Enter animal name: ");

          name = Console.ReadLine();

          manager.DisplayAnimalByName(name);
        }
        else if (choice == "3")
        {
          Console.WriteLine("Goodbye!");

          return;
        }
        else
        {
          Console.WriteLine("Invalid choice.");
        }
      }
    }
  }
}