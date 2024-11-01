using System.Management;
using System.Threading;


int processorCount = Environment.ProcessorCount;
var computerName = Environment.GetEnvironmentVariables()["COMPUTERNAME"];
var OS = Environment.GetEnvironmentVariables()["OS"];
double celsiusTemperature = 0;
uint numberOfCores = 0 ;
long RAMsize = 0 ;
var hardDiskSerial = "" ;
var MACAddress = "";
var processorSerial = "";

// Create a ManagementObjectSearcher to query the WMI data :  Windows Management Instrumentation 
ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");

foreach (ManagementObject queryObj in searcher.Get())
{
    double kelvinTemperature = Convert.ToDouble(queryObj["CurrentTemperature"].ToString());
    celsiusTemperature = (kelvinTemperature - 2732) / 10.0;
}

searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
foreach (ManagementObject queryObj in searcher.Get())
{
    numberOfCores =(uint) queryObj["NumberOfCores"];
}

searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
foreach (ManagementObject queryObj in searcher.Get())
{
    RAMsize= Convert.ToInt64(queryObj["TotalPhysicalMemory"]) / (1024 * 1024 * 1024);
}

searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
foreach (ManagementObject queryObj in searcher.Get())
{
    hardDiskSerial =(string) queryObj["SerialNumber"];
}

searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = true");
foreach (ManagementObject queryObj in searcher.Get())
{
    MACAddress =(string) queryObj["MACAddress"];
}

searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
foreach (ManagementObject queryObj in searcher.Get())
{
    processorSerial =(string) queryObj["ProcessorId"];
}

////////////////////////////////////// 

int counter = 1;
string folderPath = "C:\\Users\\faz\\Documents\\00_Innotech training\\Sessions\\session 4\\Task 1\\Generated Files";
string content = $"This File Is Created at : {DateTime.Now}\nComputer Name : {computerName}\nOperating system : {OS}\nProcessor Serial : {processorSerial}\nCurrent CPU Temperature: {celsiusTemperature} °C\nNumber of Logical Processors{processorCount}\nNumber Of Cores : {numberOfCores}\nRAM Size : {RAMsize} GB\nHard disk serial : {hardDiskSerial}\nMAC Address : {MACAddress}";

Timer timer = new Timer(CreateFile, null, 0, 1000);


Console.ReadLine(); // keep the app running 

void CreateFile(Object? state)
{
    Console.WriteLine($"The callback method was called at  {DateTime.Now}");

    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }

    string fileName = $"File{counter}.txt";
    string filePath = Path.Combine(folderPath, fileName);


    File.WriteAllText(filePath, content);

    counter += 1;
}



//the state parameter is used to pass state information to the callback method. This can be any object you want to pass to the callback method when it is invoked.
//    This can be useful if you need to pass additional information to the callback method.