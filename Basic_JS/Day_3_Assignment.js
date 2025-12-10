// Task:1
let marks=[80,90,70,85,95]
let avg=marks.reduce((acc,val)=>(acc+val),0)/marks.length
console.log(avg)

// Task:2
let numbers=[1,2,3,4,5,6,7,8,9]
let num=numbers.filter(n=>n%2==0)
console.log(num)

// Task:3
let cart={
    item:"Laptop",
    price:45000,
    quantity:2
};
console.log("Total Bill = "+cart.price*cart.quantity)

// Task:4
let movie=["Adipurush","Raone","Super20"]
movie.unshift("Simba")
movie.pop()
for(let val of movie)
    console.log(val)

// Task:7
let input=["ram","shyam","mohan"]
let output=input.map(n=>n.toUpperCase())
console.log(output)