# Zumero Helper
Some helpers to make it easier to use Zumero synchronisation.

## ZumeroHelper.Structs
This project contains structs to work with
* Guid
* DateTime
* Decimal

without using so much code at the model everytime. You can replace the generated code for a Guid column in your model
```
[PrimaryKey]
[NotNull]
[Column("Id")]

// The actual column definition, as seen in SQLite
public byte[] Id_raw { get; set; }

public static string Id_PropertyName = "Id";
		
// A helper definition that will not be saved to SQLite directly.
// This property reads and writes to the _raw property.
[Ignore]
public Guid Id { 
	get { return (Id_raw != null) ? new Guid(Id_raw) : Id = Guid.NewGuid(); } 
	set { SetProperty(Id_raw, Id_ConvertToBytes(value), (val) => { Id_raw = val; }, Id_PropertyName); }
}

// This static method is helpful when you need to query
// on the raw value.
public static byte[] Id_ConvertToBytes(Guid guid)
{
	return guid.ToByteArray();
}
```

with just one line using the new ZumeroGuid.
```
[PrimaryKey]
[NotNull]
public ZumeroGuid Id { get; set; }
```

The implemented structs are
* ZumeroGuid
* ZumeroDateTime
* ZumeroDecimal

## ToDo
* Add Tests
* Check why IConvertible is needed from SQLite.Net