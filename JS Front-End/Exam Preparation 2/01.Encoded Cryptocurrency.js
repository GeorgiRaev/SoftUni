function solve(input) {
    let message = input.shift();
    let output = [];

    for (let i = 0; i < input.length; i++) {
        let [command, arg1, arg2] = input[i].split("?");

        switch (command) {
            case "TakeEven":
                message = takeEven(message);
                output.push(message);
                break;
            case "ChangeAll":
                message = changeAll(message, arg1, arg2);
                output.push(message);
                break;
            case "Reverse":
                message = reverseSubstring(message, arg1);
                output.push(message);
                break;
            case "Buy":
                console.log(output.join("\n"));
                console.log(`The cryptocurrency is: ${message}`);
                break;
            default:
                break;
        }
    }

    function takeEven(str) {
        return str.split("").filter((char, index) => index % 2 === 0).join("");
    }

    function changeAll(str, substring, replacement) {
        const regex = new RegExp(substring, "g");
        return str.replace(regex, replacement);
    }

    function reverseSubstring(str, substring) {
        if (!str.includes(substring)) {
            console.log('error')
            return message;
        }

        const index = str.indexOf(substring);
        const reversedSubstring = substring.split("").reverse().join("");
        const newStr = str.replace(substring, "");

        return newStr + reversedSubstring;
    }
}
solve((["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"])
)
