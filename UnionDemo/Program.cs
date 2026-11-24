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

IWorker LookUpWorker(string name)
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

record EmployeeRecord(int EmployeeId, string Name) : IWorker;
record ContractorRecord(int EmployeeId, string Company, string Name) : IWorker;

interface IWorker
{
    string Name { get; }
}