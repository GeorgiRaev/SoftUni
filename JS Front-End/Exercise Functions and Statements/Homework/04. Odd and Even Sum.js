function oddAndEvenSum(input) {
    let digits = Array.from(String(input), Number);
    let oddSum = 0;
    let evenSum = 0;

    for (let i = 0; i < digits.length; i++) {
        if (digits[i] % 2 === 0) {
            evenSum += digits[i];
        } else {
            oddSum += digits[i];
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
oddAndEvenSum(3495892137259234)
