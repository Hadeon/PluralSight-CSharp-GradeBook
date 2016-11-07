using Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesTest.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[0]);
            Assert.AreEqual(grades.Length, 3);
        }

        private void AddGrades(float[] grades)
        {
            grades[0] = 89.1f;
            grades[1] = 10;
            grades[2] = 11;
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            //Must declare the variable before the changed value because this is otherwise immutable.
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "eli";
            //Must declare the variable before the changed value because this is otherwise immutable.
            name = name.ToUpper();

            Assert.AreEqual("ELI", name);
        }

        //Value Types CANNOT be references from outside methods, so the below IncrimentNumber will NOT change the value stored within this method
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            //The IncrimentNumber is expecting ref so it must be declared below.
            IncrimentNumber(ref x);
            Assert.AreEqual(47, x);
        }

        //However, Value Types CAN be changed by adding a ref because now it's pointing to the TestMethod above.
        private void IncrimentNumber(ref int number)
        {
            number += 1;
        }

        //Reference Types can be referenced from outside methods, which will change the value within the reference. Ex. GiveBookName method below
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            //In order to pass this variable to a "ref" method, you need to declare "ref"
            GiveBookName(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }

        //ref === a pointer to another pointer.
        private void GiveBookName(ref GradeBook book)
        {
            //The new book passes because the ref creates a new reference pointer for the passed book2 (removing the previous connection to the first declared reference within the ReferenceTypesPassByValue() method.
            book = new GradeBook();
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Eli";
            string name2 = "eli";
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }
        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;
            g1.Name = "Eli's Name";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
