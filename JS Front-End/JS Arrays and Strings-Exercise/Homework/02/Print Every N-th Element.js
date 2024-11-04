function solve(numbers, theStep) {
    let result = [];
    for (let i = 0; i < numbers.length; i += theStep) {

        result.push(numbers[i])

    }
    return result;
}
console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));