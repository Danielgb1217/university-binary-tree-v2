using System;
using System.Collections.Generic;
using System.Text;

namespace university_binary_tree
{
    class UniversityTree
    {
        public PositionNode Root;
        private int ContNode = 0;
        public float longestSalary = 0;
        public PositionNode temp = new PositionNode();
        private  float SumSalaryGiven = 0;
        private float salaryGiven = 0;

        public void CreatePosition(PositionNode parent, Position positionToCreate, string parentPositionName)
        {
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;

            if(Root == null)
            {
                Root = newNode;
                return;
            }
            if(parent == null)
            {
                return;
            }

            if(parent.Position.Name == parentPositionName)
            {
                if(parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                parent.Right = newNode;
                return;
            }

            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);

        }

        public void PrintTree(PositionNode from)
        {
            if (from == null) return;

            
            Console.WriteLine($"{from.Position.Name} : ${from.Position.Salary}");

            PrintTree(from.Left);
            PrintTree(from.Right);


        }

        public float AddSalaries(PositionNode from)
        {
            if (from == null) return 0;

            return from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);            
        }

        public int ContTree(PositionNode from)
        {
            if (from == null) return ContNode;                   
                 ContNode++;
                 ContTree(from.Left);
          return ContTree(from.Right);
            
        }


        public float CalculateAverageSalary()
        {
            ContNode = 0;
            return (AddSalaries(Root) / ContTree(Root));
        }

        public void CalculateLongestSalary(PositionNode from)
        {
            if (from == null) return;

            if(from.Position.Salary > longestSalary && from.Position.Salary != Root.Position.Salary)
            {
                longestSalary = from.Position.Salary;
                temp = from;
            }            
             
            CalculateLongestSalary(from.Left);
            CalculateLongestSalary(from.Right);
        }

        
        public float SalaryGiven(PositionNode from, string position)
        {
            if (from == null) return salaryGiven;

            if (from.Position.Name.Equals(position) )
            {
                salaryGiven = from.Position.Salary;
            }
            SalaryGiven(from.Right, position);
            SalaryGiven(from.Left, position);
            return salaryGiven;
        }
        

        public PositionNode FindNode(PositionNode from, string Name)
        {
            if (from == null) return temp;

            if (from.Position.Name.Equals(Name))
            {
                temp = from;
                return temp;
            }

                  FindNode(from.Left, Name);
         return   FindNode(from.Right, Name);

        }

        public float CalculateSumTax(PositionNode from)
        {
            if (from == null) return 0;

            return (from.Position.Salary * from.Position.Tax) + CalculateSumTax(from.Left) + CalculateSumTax(from.Right);
        }

    }
}
