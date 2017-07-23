# PlcOpenXmlSplitter

This project contains an App that takes a PlcOpen XMl export file of an entire Application and splits it into single files. This serves the purpose to make versioning of such PLC applications easier and to allow teamwork.


### Splits
The following tree structure shows how plcopen documents are split up into different folders and files.

```
.
+-- fileHeader.xml
+-- contentHeader.xml
+-- types
|   +-- datatypes
|       +-- datatype1.xml
|       +-- datatype2.xml
|       +-- ...
|   +-- pous
|       +-- pou1.xml
|       +-- pou2.xml
|       +-- ...
+-- instances
|   +-- configurations
|       +-- configuration1.xml
|       +-- configuration2.xml
|       +-- ...
+-- addData
|   +-- interfaces
|       +-- interface1.xml
|       +-- interface2.xml
|       +-- ...
|   +-- projectStructure
|       +-- folder1.1
|           +-- folder2.1
|               +-- ...
|               +-- object1.xml
|               +-- object2.xml
|               +-- ...
|       +-- folder1.2
|           +-- ...
|           +-- object1.xml
|           +-- object2.xml
|           +-- ...
|       +-- object1.xml
|       +-- object2.xml
|       +-- ...
```
