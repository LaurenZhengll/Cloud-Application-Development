using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;


namespace UnitTestProject1
{
  
    [TestClass]
    public class UnitTest1
    {   
 
        //Unit Test for calculation of the runtime of a task allocated to an N GHz processor.
        [TestMethod]
        public void TaskRuntime_UnitTest()
        {
            //Arrange
            double processorFrequency = 2;
            double runtime = 2.5;
            double referFrequency = 4.8;           
            double expectedTaskRuntime = 6;

            //Act    
            TaskAllocation taskallocation = new TaskAllocation("../../../Files for Unit Testing/Marking 1.tan");

            //TaskAllocation taskallocation = new TaskAllocation("../Files for Unit Testing/Marking 1.tan");
            double taskRuntime = taskallocation.TaskRuntime(processorFrequency, runtime, referFrequency);

            //Assert
            Assert.AreEqual(expectedTaskRuntime, taskRuntime);
        }
        

       
        //Unit Test for calculation of the runtime of an allocation.
        [TestMethod]
        public void AllocationRuntime_UnitTest()
        {
            //Arrange
            double[] processorFre = { 5, 4, 3, 2, 1 };
            double[] runtime = { 1, 2, 3, 4, 5 };            
            double referFre = 4;
            double expectedAlloRuntime = 34.8;           

            //Act                 
            TaskAllocation taskallocation = new TaskAllocation("../../../Files for Unit Testing/Marking 1.tan");
            double alloRuntime = taskallocation.AllocationRuntime(processorFre, runtime, referFre);

            //Assert
            Assert.AreEqual(expectedAlloRuntime, alloRuntime);
        }



        //Unit Test for calculation of the energy consumed by a task allocated to an N GHz processor.
        [TestMethod]
        public void TaskConsumedEnergy_UnitTest()
        {
            //Arrange
            double frequency = 2;
            double taskRuntime = 2.5;           
            double expectedTaskEnergy = 37.5;

            //Act               
            TaskAllocation taskallocation = new TaskAllocation("../../../Files for Unit Testing/Marking 1.tan");
            double taskEnergy = taskallocation.TaskConsumedEnergy(frequency, taskRuntime);

            //Assert
            Assert.AreEqual(expectedTaskEnergy, taskEnergy);
        }



        //Unit Test for calculation of the energy consumed by an allocation.
        [TestMethod]
        public void AllocationEnergy_UnitTest()
        {
            //Arrange
            double[] frequency = { 3, 2, 4, 5, 6 };         
            double[] taskRuntime = { 4.6, 5, 3.1, 2.5, 1.2 };           
            double expectedAlloEnergy = 1179.5;

            //Act           
            TaskAllocation taskallocation = new TaskAllocation("../../../Files for Unit Testing/Marking 1.tan");
            double alloEnergy = taskallocation.AllocationEnergy(frequency, taskRuntime);

            //Assert
            Assert.AreEqual(expectedAlloEnergy, alloEnergy);
        }


        
        //Unit Test for Validation of allocaion
        [TestMethod]
        public void AllocationValidation_UnitTest()
        {
            //Arrange          
            double totalRuntime = 5;
            double MaxiDuration = 10;
            //Act
            TaskAllocation taskallocation = new TaskAllocation("../../../Files for Unit Testing/Marking 1.tan");
            bool result = taskallocation.AllocationValidation(MaxiDuration,totalRuntime);

            //Assert
            Assert.IsTrue(result);

        }



        //Unit Test for Validation of TAN file
        [TestMethod]
        public void TanFileValidation_UnitTest()
        {
            //Arrange
            string tanFilePath = "../../../Files for Unit Testing/Marking 1.tan";    
            
            //Act
            TaskAllocation taskallocation = new TaskAllocation(tanFilePath);
            bool result = taskallocation.TanFileValidation();

            //Assert
            Assert.IsTrue(result);

        }



        //Unit Test for Validation of CSV file
        [TestMethod]
        public void CsvFileValidation_UnitTest()
        {
            //Arrange
            string csvFilePath = "../../../Files for Unit Testing/Marking 1.csv";

            //Act
            Configuration configuration = new Configuration(csvFilePath);
            bool result = configuration.CsvFileValidation();

            //Assert
            Assert.IsTrue(result);
        }
        
    }
}
