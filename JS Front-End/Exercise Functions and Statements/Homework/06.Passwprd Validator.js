function validatePassword(password) {
    // Check if password length is between 6 and 10 characters
    if (password.length < 6 || password.length > 10) {
        console.log("Password must be between 6 and 10 characters");
        if(PassMustHaveTwoDigits){
            console.log("Password must have at least 2 digits");
            return;
        }
    }
    // Check if password consists only of letters and digits
    if (!/^[a-zA-Z0-9]+$/.test(password)) {
        console.log("Password must consist only of letters and digits");
        if(PassMustHaveTwoDigits){
            console.log("Password must have at least 2 digits");
            return;
        }
    }
    // Check if password has at least 2 digits
    function PassMustHaveTwoDigits(password) {
        let digitCount = 0;
        for (let char of password) {
            if (/[0-9]/.test(char)) {
                digitCount++;
            }
        }
        if (digitCount < 2) {
            console.log("Password must have at least 2 digits");
            return;
        }
    }
    // If all conditions are met, print "Password is valid"
    console.log("Password is valid");
}

validatePassword('logIn');
validatePassword('MyPass123');
validatePassword('Pa$s$s');
