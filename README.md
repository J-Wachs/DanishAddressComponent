# Danish Address Blazor component

The Danish Address Blazor component is used to let users key in an address in Denmark. The purpose is to ensure that the
address entered, is a correct Danish address (roadname, roadnumber etc. spelled correctly). When the address is finally selected
in the component, the component returns an object containing information about the address.

The component can be configured to match the needs in the specific case, e.g. search for actual adress or access address.

The component has been developed in .NET 9.

## Fully functional example project

This repo contains a project that is the actual components, it's support classes and a demo project, where you can see
examples of various configurations of the component:

* Searching for an address in Copenhagen N and Copenhagen S (zipcodes 2200 and 2300)
* Searching for an address in Aarhus municipality (municipality code 751)
* Searching for an access address in Roskilde (zipcode 4000)

## How does it work?

The Danish Address component make use of a JavsScript library that has been released by the Danish authority 'Styrelsen
for Dataforsyning og Infrastruktur' (englisth: The board for Data Supply and Infrastructure), short SDFI. You will find it here:
https://github.com/SDFIdk/dawa-autocomplete2

The component links the JavaScript library to a textbox. The result is, that when the user begins to key in an (access) 
address, addresses that matches what the user enteres, and what the configuration of the component is set for, are displayed in
a dropdown list. When the user sees the address, the user clicks on the address. This will trigger an event in the component, and
the address is stored in the instance of an DAWAAddress object. This instance has been set as a parameter to the component.

What the next step is, is up to you.

The component has the following parameters:
* DAWAAddress Address: This is the object that will hold the (access) address selected by the user. The parameter must be set.
* string PlaceHolderText<: This is the text to be displayed in the edit box, as long as no (access) address is selected.
This parameter is optional.
* bool OnlyAccessAddresses: When set to TRUE, the component will only display access addresses. When set to FALSE it will display 
addresses.
* string? ZipCodes: This is none, one or more Danish zip codes that the returned (access) addresses must be in. If you want to have
more than one zip code, they must be seperated by the 'pipe' character ('|'). The parameter is optional.
* string? MunicipalNumbers: This is none, one or more Danish municipal numbers that the returned (access) adresses must be in. If you 
want to have more than one municipal number, they must be seperated by the 'pipe' character ('|'). The parameter is optional.

Please note, that the parameters implemented in the component, are just a subset of all the parameters that the DAWA Autocomplete2
JavaScript can understand. Look at the DAWA Autocomplete2 documentation on GitHub.

### Callback from JavaScript

As written above, when the user selects an (access) address, the address is returned to the component. This is done by the
JavaScript. When the search JavaScript is setup, it is given a Dotnet instance object, made with a call to the class
'DotNetObjectReference'. This object ensures that it is the correct instance of the callback method ('AddressSelected()' in the
component code) that is called. The callback method is tagget with the attribute 'JSInvokeable'. The callback method is passed
an object of type DAWAAddressDTO. The structure of this object has been desided by SDFI, and it cannot be changed.

The object contains the major information about an (access) address. If this does not suffice, you will need to implement a call
to the DAWA (access) address API that will return much more detailed information about an (accress) address, e.g. region. The
actual returned information, depends on the value you provide for the 'struktur' keyword.

The way DotNetReference is implemented ensures that you can have several components on the same page, and different instances
have their own callback method.

### Converting of certain returned information

In the object DAWAAddressDTO three fields are defined as decided by SDFI in the DAWA Autocomplete2 address object returned.
I have created a business object where the three fields are converted to enums. I have done this to make it more clear what the 
sigfinance of the data returned is. The three fields are:

* Status
* DarStatus
* Type

## Installation instructions

### Getting and trying out the Danish Address component

Download the repo and open the demo project in Visual Studio. Play around with the demo.

### Setting up your own project to use the Danish Address component

To use the Danish Address component in your own projects, you must add the component project to your solution. Then you must
add the 'IDAWWAAddressDTOBOConverter' to the Program.cs file of your project:

```
...
// Added for DanishAddressComponent:
builder.Services.AddScoped<IDAWAAddressDTOBOConverter, DAWAAddressDTOBOConverter>();
// End
...
```
### Adding and using the Danish Address component in your own projects

Add the Danish Address component to the relevant pages in your project.

If the page is about displaying/editing an address already stored, you must provide an instance of the DAWAAddress business
object. Dependig on how you want to use the address information in your application, you must either provide the object fully
populated or just the field Id in the Data sub-object.

It is up to you, if you want to use all information or just the Id of an address in your application.

## Modifying the Danish Address component for your own use

Maybe you do not need all the information returned. Maybe you need more information to be returned. Maybe you need to use a config
value for the DAWA Autocomplete2 JavaScript that I have not implemented. Maybe you want a map displayed and focused on the address.

Your organisation can have other requirements that are not covered by my project. Please feel free to adapt a local 
version to fit your needs.

## Found a bug?

Please create an issue in the repo.

## Known issues (Work in progress)

None at this time.

## FAQ

### What is the difference between an 'address' and an 'access address'?

Imagine an appartment building with two staircases, number 5 and number 7 on the road. The building has 2 floors. The appartment to
the left on the top floor, has the address 'Someroad 5, 1. Left'. This is the actual 'address' of the appartment. However, to get
to the appartment you will have to go to the 'access address', which is 'Someroad 5'. When 'addresses' are returned, there is the
'access address' Id in the returned DAWA Address object.

### Why isn't the CSS file scoped under the component?

First, scoping the CSS file under the component, is call CSS Isolation. The reason why, I did not scope the CSS file under the 
component is, that the JavaScript called, creates objects and adds style classes to these. As the name is comming from the JavaScript,
there is no way for the Blazor runtime to add the identifier to the objects created by the JavaScript. Having the CSS file un-scoped
restults in, that the class names are the original ones, and they are applied as need/expected.

### Why only Danish (access) addresses?

The JavaScript used is created by SDFI and uses the two services called DAWA (Danish Web Addresses) and DAR (Danish Address Database 
(Register in Danish)). There are other services on the Internet that can provide information about addresses in other countries.
Examples are Google and OpenStreetMap.
 
### I cannot find a specific road. Why not?

In the Danish language vi often use shorts for some words. When roads are named, sometimes the short is used, sometimes the whole
word.

One example is the road 'Gammel Kongevej' in Copenhagen. Sometime it is spelled 'Gl. Kongevej'. The city 'Kongens Lyngby' is
sometimes spelled 'Kgs. Lyngby'. If you cannot find the road, try other spelling.

Then there is a special case. When a piece of land is to be prepared for housing, roads are planned and named. If you know that a
given road exists, but it cannot be found, then it might be that the naming of the road has not yet been process and published in
DAWA. This is seldom the case, but it happens. It is also possible that the road has been renamed.
