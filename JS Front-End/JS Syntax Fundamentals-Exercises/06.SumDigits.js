function solve(number) {
    let numString = number.toString();
    let sum = 0;

    for (let i = 0; i < numString.length; i++) {
        sum += Number(numString[i]);
    }
    console.log(sum)
}
solve(245678);
solve(97561);
solve(543);