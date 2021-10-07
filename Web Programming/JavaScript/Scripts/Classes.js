/*let obj = {
    empId:1,
    empName:"sri",
    empAddress:"Narasaraopet"
}
obj.empSalary=56000;//u can assign new properties to the 
//Singleton objects in JS
console.log(obj.empId)
console.log(obj.empName)
console.log(obj.empAddress)
console.log(obj.empSalary)
//Treat obj like a array
for (let prop in obj) {
    console.log("Property : " +prop +"  Value :"+obj[prop]);
}*/
//creating classes using ES6
class Employee
{
    constructor(id,name,address,salary)
    {
        this.id=id;
        this.name=name;
        this.address=address;
        this.salary=salary;
    }
    //creating member function in JS
    display(){
        return `${this.name} from ${this.address}`;
    }
}
    let emp=new Employee(1,"Prashanth","NRT",50000);
    let emp2=new Employee(1,"Prathyusha","NRT",50000);
    let emp3=new Employee(1,"Anusha","NRT",50000);
    let emp4=new Employee(1,"Aparna","NRT",50000);
    console.log(emp.name);
    console.log(emp2.name);
    console.log(emp3.name);
    console.log(emp4.name);
    console.log(emp.display());
    console.log(emp2.display());
    console.log(emp3.display());
    console.log(emp4.display());