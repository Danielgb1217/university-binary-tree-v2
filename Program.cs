 using System;

namespace university_binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Position rectorPosition = new Position("rector", 1000,0.3F);
            Position vicFinPosition = new Position("Vicerector", 750, 0.27F);
            Position vicAcadPosition = new Position("Vicerector academico", 780, 0.22F);
            Position contadorPosition = new Position("contador", 500, 0.15F);
            Position jefeFinPosition = new Position("jefe financiero", 610, 0.18F);
            Position secFin1Position = new Position("secretaria financiera 1", 350, 0.12F);
            Position secFin2Position = new Position("secretaria financiera 2", 310, 0.11F);


            Position jefeRegPosition = new Position("jefe reg", 640, 0.17F);
            Position asist2Position = new Position("Asistente 2", 170, 0.07F);
            Position secTreg2Position = new Position("secretaria Treg 2", 360, 0.05F);            
            Position secTreg1Position = new Position("secretaria Treg 1", 400, 0.06F);
            Position mensajeroPosition = new Position("Mensajero", 90, 0.01F);
            Position asist1Position = new Position("Asistente 1", 250, 0.12F);
           // Position alumno1Position = new Position("Alumno", 2000000, 0.001F);





            UniversityTree universityTree = new UniversityTree();
            universityTree.CreatePosition(null, rectorPosition, null);
            universityTree.CreatePosition(universityTree.Root, vicFinPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, contadorPosition, vicFinPosition.Name);           
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, jefeFinPosition, vicFinPosition.Name);


            universityTree.CreatePosition(universityTree.Root, vicAcadPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeRegPosition, vicAcadPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secTreg2Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secTreg1Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, asist2Position, secTreg1Position.Name);
            universityTree.CreatePosition(universityTree.Root, mensajeroPosition, asist2Position.Name);
            universityTree.CreatePosition(universityTree.Root, asist1Position, secTreg1Position.Name);
           // universityTree.CreatePosition(universityTree.Root, alumno1Position, asist1Position.Name);





            universityTree.PrintTree(universityTree.Root);
            Console.WriteLine("------------------------------------------------------------------------");
            float totalSalary = universityTree.AddSalaries(universityTree.Root);
            Console.WriteLine($"Total Salaries : {totalSalary}");
            Console.WriteLine("------------------------------------------------------------------------");
            universityTree.CalculateLongestSalary(universityTree.Root);
            Console.WriteLine($"Longest Salary is : {universityTree.longestSalary}" + " Salary of " + universityTree.temp.Position.Name);
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Number of Nodes : {universityTree.ContTree(universityTree.Root)}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Average Salary is : {universityTree.CalculateAverageSalary()}");
            Console.WriteLine("------------------------------------------------------------------------");

            PositionNode NodeFound = new PositionNode();
            NodeFound = universityTree.FindNode(universityTree.Root, "Vicerector academico");  //Position given to research the salary 
            Console.WriteLine($"salary to position given is : {universityTree.AddSalaries(NodeFound) }");

            Console.WriteLine($"salary to position given is(only) : {universityTree.SalaryGiven(universityTree.Root, "contador") }");

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"Total Tax is : {universityTree.CalculateSumTax(universityTree.Root)}");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
