function solve(grade){
    const result = formatGrade(grade);
    function formatGrade(grade) {
        let formatGrade = '';
    
        if (grade < 3) {
            formatGrade = `Fail ${'(2)'}`;
        } else if (grade < 3.5) {
            formatGrade = `Poor (${grade.toFixed(2)})`;
        } else if (grade < 4.5) {
            formatGrade = `Good (${grade.toFixed(2)})`;
        } else if (grade < 5.5) {
            formatGrade = `Very good (${grade.toFixed(2)})`;
        } else {
            formatGrade = `Excellent (${grade.toFixed(2)})`;
        }
        return formatGrade;
    }
    console.log(result);
}
solve(2.33)