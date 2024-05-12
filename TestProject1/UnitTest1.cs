using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using ClassLibrary;
using Lab_12_3;
using Lav_12_3;
namespace TestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodToString1()
        {
            string test = "Бибизяна";
            var mmm = new Point<string>(test);
            Assert.AreEqual(test, mmm.ToString());
        }
        [TestMethod]
        public void TestMethodToString2()
        {
            int test = 12;
            var mmm = new Point<int>(test);
            string test2 = "12";
            Assert.AreEqual(test2, mmm.ToString());
        }
        [TestMethod]
        public void TestMethodCreateTree()
        {
            MyTree<MusicalInstrument> myTree = new MyTree<MusicalInstrument>(5);
            Assert.AreEqual(5, myTree.Count);
        }
        [TestMethod]
        public void TestMethodTransFromToFindTree()
        {
            MyTree<MusicalInstrument> myTree = new MyTree<MusicalInstrument>(10);
            MusicalInstrument muz2 = new MusicalInstrument { Title = "Смешарики" };
            myTree.AddPoint(muz2);
            myTree.TransFromToFindTree();
            myTree.FindMax();
            Assert.AreEqual(muz2, myTree.FindMax());
        }
        [TestMethod]
        public void TestMethodFindMaxEmpty()
        {
            MyTree<MusicalInstrument> myTree = new MyTree<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument();
            myTree.ClearTree();
            Assert.ThrowsException<InvalidOperationException>(() =>myTree.FindMax());
        }
    }
}
