//create a class to represent a food item in a restaurent
class Item
{
    constructor(id,name,price)
    {
        this.itemId=id;
        this.itemName=name;
        this.itemPrice=price;
    }
}
let foodItems=[];//food menu

let addFoodItem=(item)=>foodItems.push(item);

let findItem=(id)=>foodItems.find((f)=>f.itemId==id);

let findItems=(name)=>foodItems.filter((f)=>f.itemName.includes(name));//includes is similar to contains of c# string.

let updateFoddItem=(item)=>{
    let found=findItem(item.itemId);
    found.itemName=item.itemName;
    found.itemPrice=item.itemPrice;
}

function test()
{
    addFoodItem(new Item(1,"Dosa",50));
    addFoodItem(new Item(2,"Idle",50));
    addFoodItem(new Item(3,"Poori",50));
    addFoodItem(new Item(4,"Roti",50));
    addFoodItem(new Item(5,"Upma",50));
    for(const item of foodItems)
    {
        console.log(item.itemName);
    }
}
test();