# README - Projet Console avec EF Core

## Mise en place

1. Création du projet `Console`
2. Dans la solution, on crée un projet `Bibliothèque de class` nommée `Domain` - Regroupement de toutes les class du projet
   1. Création d'un dossier `Models`
3. Dans la solution, on crée un projet `Bibliothèque de class` nommée `DAL` - Data Access Layout : intéraction avec la DB
   1. Création d'un dossier `Database`
   2. Dans le dossier `Database` création d'un dossier `Configurations` et `Seeds`
4. Ajout des dépendance entre le projet:

   1. Dans le projet `Console`:
      1. clique droit sur `Dépendances`
      2. `Ajouter des références`
      3. Cocher `Domain` et `DAL`
   1. Dans le projet `DAL`:
      1. clique droit sur `Dépendances`
      2. `Ajouter des références`
      3. Cocher `Domain`

5. Installation des packages NuGet (⚠️ la version MAJEUR du package doit correspondre à la version de .NET du projet):
   1. Dans le projet `DAL` :
      1. `Microsoft.EntityFrameworkCore`
      2. `Microsoft.EntityFrameworkCore.Design`
      3. `Microsoft.EntityFrameworkCore.Tools`
      4. `Microsoft.EntityFrameworkCore.SqlServer` (ou autre provider selon la DB utilisée)
   2. Dans le projet `Console`:
      1. `Microsoft.EntityFrameworkCore.Design`

## Création des tables

1.  Dans le projet `Domain`:
    1. Dans le dossier `Models` création des class (Ex: `Car.cs`, `Brand.cs`...)
2.  Dans le projet `DAL`:
    1. Dans le dossier `Database/Configurations` création des class de configurations (Ex: `CarConfig.cs`, `BrandConfig.cs`...)
    2. Dans le dossier `Database/Seeds` création des class de seeds (Ex: `CarSeed.cs`, `BrandSeed.cs`...)
    3. Création du contexte de la DB (Ex: `AppDbContext.cs`)
    4. Ajout des configurations et seeds dans le contexte de la DB et le `DbSet` pour chaque table

## Migration et création de la DB

1. Ouvrir la `Console du gestionnaire de package` (Outils > Gestionnaire de package NuGet > Console du gestionnaire de package)
2. Sélectionner le projet `DAL` comme projet par défaut dans la console
3. Commande pour créer une migration:
   ```
   Add-Migration <NomDeLaMigration>
   ```
4. Commande pour appliquer la migration et créer la DB:
   ```
   Update-Database
   ```

## Utilisation dans le projet Console

Dans le projet `Console`, dans le `Program.cs` ou autre fichier, on peut utiliser le contexte de la DB pour effectuer des opérations CRUD.

### Connexion à la DB

```csharp
using (DbContextDemo db = new DbContextDemo()) {
    // Opérations CRUD ici
}
```

### Exemple d'insertion

```csharp
using (DbContextDemo db = new DbContextDemo()) {
    // Création d'une nouvelle marque et d'une nouvelle voiture
    var newBrand = new Brand {
        Name = "Tesla"
    };

    var newCar = new Car {
        Model = "Model S",
        Brand = newBrand,
        Year = 2020
    };
    // Ajout de la voiture (la marque sera ajoutée automatiquement grâce à la relation)
    db.Cars.Add(newCar);
    // Sauvegarde des changements dans la DB
    db.SaveChanges();
}
```

### Exemple de lecture

```csharp
using (DbContextDemo db = new DbContextDemo()) {
    // Récupération de toutes les voitures avec leurs marques associées
    var cars = db.Cars.Include(c => c.Brand).ToList();
    foreach (var car in cars) {
        Console.WriteLine($"{car.Model} - {car.Brand.Name} - {car.Year}");
    }
}
```

### Exemple de mise à jour

```csharp
using (DbContextDemo db = new DbContextDemo()) {
    // Récupération de la voiture à mettre à jour
    var carToUpdate = db.Cars.FirstOrDefault(c => c.Id == 1);
    if (carToUpdate != null) {
        carToUpdate.Model = "Model X";
        db.SaveChanges();
    }
}
```

### Exemple de suppression

```csharp
using (DbContextDemo db = new DbContextDemo()) {
    // Récupération de la voiture à supprimer
    var carToDelete = db.Cars.FirstOrDefault(c => c.Id == 1);
    if (carToDelete != null) {
        db.Cars.Remove(carToDelete);
        db.SaveChanges();
    }
}
```

### Gestion des erreurs

Attention les opération `Remove()` et `SaveChanges()` peuvent générer des exceptions (ex: violation de contrainte FK). Il est conseillé d'utiliser des blocs `try-catch` pour gérer ces erreurs.
