using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;
using System.Reflection;

namespace TyrePressureMonitoringSystemTests
{
    public class TyrePressureMonitorTester
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private Mock<ISensor> mockSensor;

        [SetUp]
        public void InitializeSensor()
        {
            this.mockSensor = new Mock<ISensor>();
        }

        [TestCase(16.999999, ExpectedResult = true)]
        [TestCase(21.000001, ExpectedResult = true)]
        public bool SensorReadingBellowOrAboveLimitShouldSetAlarm(double pressureSensorValue)
        {
            Alarm alarm = new Alarm();
            FieldInfo sensor = alarm.GetType().GetField("_sensor", BindingFlags.NonPublic | BindingFlags.Instance);
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(pressureSensorValue);
            sensor.SetValue(alarm, mockSensor.Object);
            alarm.Check();
            return alarm.AlarmOn;
        }

        [TestCase(17, ExpectedResult = false)]
        [TestCase(19, ExpectedResult = false)]
        [TestCase(21, ExpectedResult = false)]
        public bool SensorReadingWithinLimitsShouldNotTriggerAlarmAlarm(double pressureSensorValue)
        {
            Alarm alarm = new Alarm();
            FieldInfo sensor = alarm.GetType().GetField("_sensor", BindingFlags.NonPublic | BindingFlags.Instance);
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(pressureSensorValue);
            sensor.SetValue(alarm, mockSensor.Object);
            alarm.Check();
            return alarm.AlarmOn;
        }
    }
}