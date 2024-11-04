function solve(numbers, rotations) {

    for (let i = 0; i < rotations; i++) {
     let firstNumber = numbers.shift();
     numbers.push(firstNumber);   
    }
    console.log(numbers.join(' '));
}

solve([2, 4, 15, 31], 5)
