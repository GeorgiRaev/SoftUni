function numbersAndSum(a, b) {
    let numbers = '';
    let sum = 0;
    for (let i = a; i <= b; i++) {
        numbers+= i +' ';
        sum += i;
    }
    console.log(numbers);
    console.log(`Sum: ${sum}`);
}

numbersAndSum(0, 26);