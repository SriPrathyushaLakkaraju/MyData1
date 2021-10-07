let intValues=[1,2,3,4,5,6];
//syntax of arrays in js
intValues.push(7,8,9);
for(let index=0;index<intValues.length;index++){
    document.write(intValues[index]+"<br/>")
    console.log(intValues[index])
}
console.log(typeof(intValues))
let choice=parseInt(prompt("Enter element to remove"));
let index=intValues.indexOf(choice);
if(index==-1)
{
    console.log("No element found");
}
else{
    intValues.splice(index,1);
}
console.log(intValues)