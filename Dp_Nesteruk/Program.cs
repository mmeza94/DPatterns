


// using AbstractFactory;
using AbstractFactoryOCP;
using Factory.FactoryMethod;
using Factory.FactoryMethodAsync;
using Factory.ThemeFactory;
using System;




#region FactoryMethod
// var point = Point.NewPolarPoint(2.3,5.4);
// Console.WriteLine(point.ToString());
#endregion



#region FactoryMethodAsync

// Foo x = await Foo.CreateAsync();
// Console.WriteLine(x.MyProperty);

#endregion




#region TrackingThemeFactory

// var factory = new TrackingThemeFactory();
// var darkTheme = factory.CreateTheme(true);
// var light = factory.CreateTheme(false);
// Console.WriteLine(factory.Info);

// var factory2 = new ReplaceableThemFactory();
// var magictheme = factory2.CreateTheme(true);
// Console.WriteLine(magictheme.value.BgrColor);
// factory2.ReplaceTheme(false);
// Console.WriteLine(magictheme.value.BgrColor);


#endregion



#region Abstract Factory

// var machine = new HotDrinkMachine();
// var coffee = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee,60);
// coffee.Consume();

#endregion



#region Abstract Factory OCP

var machine = new AbstractFactoryOCP.HotDrinkMachine();
var drink = machine.MakeHotDrink();


#endregion
























