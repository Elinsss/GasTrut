using GasTrut;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ListBox listBox = new ListBox();
            Form2 form2 = new Form2();
            form2.Event(listBox);
        }
        [TestMethod]
        public void TestMethod2()
        {
            ListBox listBox = new ListBox();
            Form4 form4 = new Form4();
            form4.Event(listBox);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form2 form2 = new Form2();
            ListBox listBox = new ListBox();

            form2.Event(listBox);
            form2.Controls.Add(listBox);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form4 form4 = new Form4();
            ListBox listBox = new ListBox();

            form4.Event(listBox);
            form4.Controls.Add(listBox);
        }
    }
}
