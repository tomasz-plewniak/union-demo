List<EmployeeRecord> employees =
[
    new(1, "John Doe"),
    new(2, "Sue Storm")
];
  
List<ContractorRecord> contractors =
[
    new(3, "ABC Corp", "Jane Doe"),
    new(4, "XYZ Inc", "Bob Smith")
];

do
{ 
    Console.WriteLine("What name should we look up: "); 
    string nameToLookUp = Console.ReadLine();
    
    Worker worker = LookUpWorker(nameToLookUp);

    string message = $"Name: {worker.Name}";
    Console.WriteLine(message);

    Console.ReadLine();
    Console.Clear();
    
} while (1 == 1);


Worker LookUpWorker(string name)
{
    EmployeeRecord? e = employees.Where(x => string.Compare(x.Name, name) == 0).FirstOrDefault();

    if (e is not null)
    {
        return e;
    }
    
    ContractorRecord? c = contractors.Where(x => string.Compare(x.Name, name) == 0).FirstOrDefault();

    if (c is not null)
    {
        return c;
    }

    throw new Exception("Worker not found");
}

union Worker(EmployeeRecord, ContractorRecord, string);

/*record EmployeeRecord(int EmployeeId, string Name) : IWorker;
record ContractorRecord(int EmployeeId, string Company, string Name) : IWorker;

interface IWorker
{
    string Name { get; }
}*/

record EmployeeRecord(int EmployeeId, string Name);
record ContractorRecord(int EmployeeId, string Company, string Name);