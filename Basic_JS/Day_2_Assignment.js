// Part-A
let x=40,y=90
console.log(x+y)

let a="Ankit"
console.log("Hello "+a)

let b=89
if(b%2==0)
    console.log("Even")
else
    console.log("Odd")

let c=8,d=4,e=9
max=(c>d)?(c>e?c:e):(d>e?d:e)
console.log(max)

console.log(a.length)

let f="Srivastava"
console.log(a+f)

let g=0
if(g>0)
    console.log("Positive")
else if(g<0)
    console.log("Negative")
else
    console.log("Zero")

for(let i=1;i<11;i++)
    console.log(c+" * "+i+" = "+(c*i))

let sum=0
for(let i=1;i<11;i++)
    sum+=i
console.log("Sum of 10 natural numbers: "+sum)

let h=3
switch (h) {
    case 1:
        console.log("Monday")
        break;
    case 2:
        console.log("Tuesday")
        break;
    case 3:
        console.log("Wednesday")
        break;
    case 4:
        console.log("Thursday")
        break;
    case 5:
        console.log("Friday")
        break;
    case 6:
        console.log("Saturday")
        break;
    case 7:
        console.log("Sunday")
        break;

    default:
        break;
}

function factorial(f){
    let fact=1;
    for(let j=f;j>0;j--)
        fact*=j;
    return fact
}
console.log(factorial(5))

function voting_eligibility(age){
    if(age>18)
        return true
    else
        return false
}
console.log(voting_eligibility(19))


// Part-B

function prime(num){
    if(num<=1)
        return false
    for(let i=2;i<num;i++){
        if(num%i==0)
            return false
    }
    return true
}
console.log(prime(49))

function sum_of_digits(num){
    let sum=0
    while(num>0){
        let a=num%10;
        sum+=a
        num=Math.floor(num/10)
    }
    return sum
}
console.log(sum_of_digits(49))

function reverse_string(name){
    for(let i=name.length-1;i>=0;i--)
        console.log(name[i])
}
reverse_string("Ankit")

function arithmetic(a,b,c){
    
}
arithmetic(5,6,"+")

function vowels(str){
    a=str.toLowerCase()
    let z=0
    for(let i=0;i<a.length;i++){
        b=a[i]
        if(b=='a' || b=='e' || b=='i' || b=='o' || b=='u')
            z++
    }
    return z
}
console.log(vowels("ankit"))

function fibonacci(n){
    a=0
    b=1
    console.log(a)
    console.log(b)
    c=a+b
    for(let i=3;i<=n;i++){
        console.log(c)
        a=b
        b=c
        c=a+b

    }
}
fibonacci(7)

ar=[4,6,87,3,2,90]
function max_min(arr){
    let max=arr[0]
    let min=arr[0]
    for(let i=0;i<arr.length;i++){
        if(max<arr[i])
            max=arr[i]
        if(min>arr[i])
            min=arr[i]
    }
    console.log("Max: "+max)
    console.log("Min: "+min)
}
max_min(ar)

ch='-'
switch (ch) {
    case '+':
        console.log("Add")
        break;
    case '-':
        console.log("Sub")
        break;
    case '*':
        console.log("Mul")
        break;
    case '/':
        console.log("Div")
        break;

    default:
        break;
}

function armstrong(num){
    let c=0
    let temp=num
    let sum=0
    while(temp>0){
        temp=Math.floor(temp/10)
        c++
    }
    temp=num
    while(temp>0){
        sum=sum+(Math.pow(temp%10,c))
        temp=Math.floor(temp/10)
    }
    if(num==sum)
        return true
    else
        return false
}
console.log(armstrong(1634))