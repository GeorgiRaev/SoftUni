function solve(number, ...operations) {
    

    for (let i = 0; i < operations.length; i++) {
        if (operations[i] === 'chop') {
            console.log(number /= 2);
        } else if (operations[i] === "dice") {
            console.log(number = Math.sqrt(number));
        }
        else if (operations[i] === "spice") {
            console.log(number += 1);
        }
        else if (operations[i] === "bake") {
            console.log(number *= 3);
        }
        else if (operations[i] === "fillet") {
            number *= 0.8;
            console.log(number.toFixed(1));
        }
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');