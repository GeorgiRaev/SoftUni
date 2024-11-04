namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        private int memoryCapacity = 1000;
        int photoSize = 100;
        int appSize = 300;
        private string appName = "Sony";

        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0,device.Applications.Count);

        }
        [Test]
        public void Test_TakePhoto()
        {
            bool result = device.TakePhoto(photoSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity - photoSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test_TakePhoto_Doesnt_Work_Correctly()
        {
            bool result = device.TakePhoto(memoryCapacity + photoSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_InstallApp_Correctly()
        {
             string result = device.InstallApp(appName, appSize);

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity - appSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(true, device.Applications.Contains(appName));
            Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
        }

        [Test]
        public void Test_InstallApp_Doesnt_Work_Correctly()
        {
            Assert.Throws<InvalidOperationException>(()=>
            device.InstallApp(appName, 5000));
            
        }

        [Test]
        public void Test_Format_Device_Work_Correctly()
        {
            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);

            device.FormatDevice();

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);

        }

        [Test]
        public void Test_Get_Device_Status_Works_Correctly()
        {
            device.InstallApp(appName, appSize);
            device.InstallApp(appName + "2", appSize + 30);
            device.TakePhoto(photoSize);
            var result = device.GetDeviceStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: 1000 MB, Available Memory: 270 MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: Sony, Sony2");
            Assert.AreEqual(sb.ToString().TrimEnd(), result);

        }
    }
}