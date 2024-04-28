using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScanInService
{
    private const string ScanInsFilePath = "scanins.txt";

    public List<int> GetScannedInSessions(int studentId)
    {
        List<int> scannedSessions = new List<int>();

        if (File.Exists(ScanInsFilePath))
        {
            string[] lines = File.ReadAllLines(ScanInsFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int scannedStudentId) && scannedStudentId == studentId)
                {
                    if (int.TryParse(parts[1], out int sessionId))
                    {
                        scannedSessions.Add(sessionId);
                    }
                }
            }
        }

        return scannedSessions;
    }

    public void ScanIn(int studentId, int sessionId)
    {
        using (StreamWriter writer = File.AppendText(ScanInsFilePath))
        {
            writer.WriteLine($"{studentId},{sessionId}");
        }
    }
}
