# RegDB

![RegDB Logo](https://github.com/Orfeous/regdb/raw/main/Logo.png)

RegDB is an extremely simple key-value "database" backed by Windows Registry.

## Usage

```Powershell
# Get value
regdb -op Get -key SomeKey
# Add new key-value pair
regdb -op Set -key SomeKey -value SomeValue
# Remove value
regdb -op UnSet -key SomeKey
```

## Return Codes

- **0** - When the requested operation was successful.
- **1** - When the requested operation failed.

### App Icon

<a href="https://www.flaticon.com/free-icons/cat" title="cat icons" target="blank">Cat icons created by Freepik - Flaticon</a>
