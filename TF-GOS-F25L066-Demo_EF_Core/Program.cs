// See https://aka.ms/new-console-template for more information
using DAL.Database;
using Domain.CustomEnums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (DbContextDemo db = new DbContextDemo()) {
    Console.WriteLine("Je suis connecté!");

    /*
    Car c1 = new Car() { 
        Model = "Polo",
        Price = 100,
        RegistrationDate = DateTime.Now,
        State = CarStateEnum.FOR_PARTS
    };

    db.Cars.Add(c1);
    db.SaveChanges();
    */

    // Récupération d'une liste de voiture
    var voitures = db.Cars.Include(c => c.Brand);

    foreach (var v in voitures) {
        Console.WriteLine($"{v.Id} - {v.Model} - {v.Brand.Name}");
    }

    // Récupération d'une voiture
    var mx = db.Cars.FirstOrDefault(c => c.Model == "MX-5" && c.State == CarStateEnum.NEW);
    if(mx is not null)
    {
        // Update
        mx.State = CarStateEnum.FOR_PARTS;
        db.SaveChanges();
    }

    var poloId3 = db.Cars.FirstOrDefault(c => c.Id == 3);
    if (poloId3 is not null) {
        // Delete
        db.Cars.Remove(poloId3);
        db.SaveChanges();
    }
}