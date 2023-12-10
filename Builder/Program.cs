
using static System.Console;


#region HtmlBuilder

// // if you want to build a simple HTML paragraph using StringBuilder
// using System.Text;
// using DotNetDesignPatternDemos.Creational.Builder;
// using static System.Console;


// var hello = "hello";
//       var sb = new StringBuilder();
//       sb.Append("<p>");
//       sb.Append(hello);
//       sb.Append("</p>");
//       WriteLine(sb);

//       // now I want an HTML list with 2 words in it
//       var words = new[] {"hello", "world"};
//       sb.Clear();
//       sb.Append("<ul>");
//       foreach (var word in words)
//       {
//         sb.AppendFormat("<li>{0}</li>", word);
//       }
//       sb.Append("</ul>");
//       WriteLine(sb);

//       // ordinary non-fluent builder
//       var builder = new HtmlBuilder("ul");
//       builder.AddChild("li", "hello");
//       builder.AddChild("li", "world");
//       WriteLine(builder.ToString());

//       // fluent builder
//       sb.Clear();
//       builder.Clear(); // disengage builder from the object it's building, then...
//       builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
//       WriteLine(builder);



#endregion



#region Inheritance Builer

using DesignPatterns;



var me = Person.New
        .Called("Dmitri")
        .WorksAsA("Quant")
        .Born(DateTime.UtcNow)
        .Build();
      Console.WriteLine(me);



#endregion



#region Stepwise Builder

// using StepwiseBuilder;

// var car = CarBuilder.Create()
//         .OfType(CarType.Crossover)
//         .WithWheels(18)
//         .Build();
//       Console.WriteLine(car);


#endregion



#region Functional Builder

// using DotNetDesignPatternDemos.Creational.Builder;

// var pb = new PersonBuilder();
//       var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();




#endregion



#region Faceted Builder

// using DotNetDesignPatternDemos.Creational.BuilderFacets;

// var pb = new PersonBuilder();
//       Person person = pb
//         .Lives
//           .At("123 London Road")
//           .In("London")
//           .WithPostcode("SW12BC")
//         .Works
//           .At("Fabrikam")
//           .AsA("Engineer")
//           .Earning(123000);

//       WriteLine(person);



#endregion





