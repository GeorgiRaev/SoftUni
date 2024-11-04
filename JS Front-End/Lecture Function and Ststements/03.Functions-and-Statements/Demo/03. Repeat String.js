function solve(inputString,repeatCount){
    let result = '';
    for(let i = 0; i<repeatCount;i++){
        result+=inputString;
    }
    console.log(result);
}
solve("String", 2)