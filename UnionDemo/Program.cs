List<EmployeeRecord> employees =
[
    new(1, "John Doe"),
    new(2, "Sue Storm")
];
  
List<ContractorRecord> contractors =
[
    new("C001", "ABC Corp", "Jane Doe"),
    new("C002", "XYZ Inc", "Bob Smith")
];

do
{ 
    Console.WriteLine("What name should we look up: "); 
    string nameToLookUp = Console.ReadLine() ?? string.Empty;
    
    Worker worker = LookUpWorker(nameToLookUp);

    string message = worker switch
    {
        EmployeeRecord employee => $"{employee.EmployeeId}: {employee.Name}",
        ContractorRecord contractor => $"{contractor.ContractorId}: {contractor.Name} from {contractor.Company}",
        DemoRecord demo => demo.Test,
        string s => s
    };
    
    Console.WriteLine(message);

    Console.ReadLine();
    Console.Clear();
    
} while (true);


Worker LookUpWorker(string name)
{
    EmployeeRecord? e = employees.FirstOrDefault(x => string
        .Compare(x.Name, name, StringComparison.Ordinal) == 0);

    if (e is not null)
    {
        return e;
    }
    
    ContractorRecord? c = contractors.FirstOrDefault(x => string
        .Compare(x.Name, name, StringComparison.Ordinal) == 0);

    if (c is not null)
    {
        return c;
    }

    return new DemoRecord("Worker not found");
}

union Worker(EmployeeRecord, ContractorRecord, DemoRecord, string);

/*record EmployeeRecord(int EmployeeId, string Name) : IWorker;
record ContractorRecord(int ContractorId, string Company, string Name) : IWorker;

interface IWorker
{
    string Name { get; }
}*/

record EmployeeRecord(int EmployeeId, string Name);
record ContractorRecord(string ContractorId, string Company, string Name);
record DemoRecord(string Test);