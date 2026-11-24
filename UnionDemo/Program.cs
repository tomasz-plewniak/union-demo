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

void LookUpWorker(string name)
{
    EmployeeRecord? e = employees.Where(x => string.Compare(x.Name, name) == 0).FirstOrDefault();
    ContractorRecord? c = contractors.Where(x => string.Compare(x.Name, name) == 0).FirstOrDefault();
}

record EmployeeRecord(int EmployeeId, string Name);
record ContractorRecord(int EmployeeId, string Company, string Name);
