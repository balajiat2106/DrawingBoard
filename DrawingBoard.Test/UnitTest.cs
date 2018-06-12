using DrawingBoard.Src;
using DrawingBoard.Src.Helpers;
using DrawingBoard.Src.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingBoard.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Create_Line_Before_Canvas()
        {
            string result = Commander.InvokeCommand("l", new[] { "1", "2", "6", "2" });

            Assert.AreEqual(Messages.Exception, result);
        }

        [TestMethod]
        public void Create_Rectangle_Before_Canvas()
        {
            string result = Commander.InvokeCommand("r", new[] { "1", "2", "6", "2" });

            Assert.AreEqual(Messages.Exception, result);
        }

        [TestMethod]
        public void Create_Canvas()
        {
            string result = Commander.InvokeCommand("c", new[] { "20", "4" });

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Negative_Parameter_To_Create_Canvas()
        {
            string result = Commander.InvokeCommand("c", new[] {"-10", "2"});

            Assert.AreEqual(Messages.ArgumentException,result);
        }

        [TestMethod]
        public void Parameters_Of_Wrong_Format_To_Create_Canvas()
        {
            string result = Commander.InvokeCommand("c", new[] { "kjdsjadk", "2" });

            Assert.AreEqual(Messages.FormatException, result);
        }

        [TestMethod]
        public void Parameter_With_Spaces_To_Create_Canvas()
        {
            string result = Commander.InvokeCommand("c", new[] { "20  ", "4      " });

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Create_Line()
        {
            string result = Commander.InvokeCommand("l", new[] { "1", "2", "6", "2" });

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Create_Rectangle()
        {
            string result = Commander.InvokeCommand("l", new[] { "14", "1", "18", "3" });

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Bucket_Fill()
        {
            string result = Commander.InvokeCommand("b", new[] { "10", "3", "o" });

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Create_Line_Outside_The_Canvas_Boundary()
        {
            string result = Commander.InvokeCommand("l", new[] { "15", "55" });

            Assert.AreEqual(Messages.IndexOutOfRangeException, result);
        }

        [TestMethod]
        public void Create_Rectangle_Outside_The_Canvas_Boundary()
        {
            string result = Commander.InvokeCommand("r", new[] { "15", "55", "63", "900" });

            Assert.AreEqual(Messages.IndexOutOfRangeException, result);
        }

        [TestMethod]
        public void Wrong_Command_Overall()
        {
            string result = Commander.InvokeCommand("l5dsf", new[] { "15", "gh32", "400", "652", "789sad", "dsad" });

            Assert.AreEqual(Messages.ArgumentException, result);
        }

        [TestMethod]
        public void Help_Check()
        {
            string result = Entry.Submain("help");

            Assert.AreEqual(Messages.Help, result);
        }

        [TestMethod]
        public void ClearCanvas()
        {
            string result = Commander.InvokeCommand("cc", new[]{""});

            Assert.AreEqual(Messages.Success,result);
        }
    }
}
