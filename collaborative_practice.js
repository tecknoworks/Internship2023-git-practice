const readline = require('readline');

const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
const prompt = (query) => new Promise((resolve) => rl.question(query, resolve));

const printMenu = () => {
    console.log(`
    Select an option:
        1. List all users
        0. Exit
    `);
};

const listUsers = (users) => {
    console.log("\nListing current users:");
    const output = users
        .map(user => `ID: ${user.id}\nFirst name: ${user.firstName}\nLast name: ${user.lastName}\n`)
        .join("\n");
    console.log(output);
};

const runProgram = async () => {
    let users = [
        { id: 1, firstName: "John", lastName: "Smith" }
    ];
    while (true) {
        try {
            printMenu();

            let option = await prompt("Option: ");
            switch (option) {
                case "1":
                    listUsers(users);
                    break;
                case "0":
                    rl.close();
                    return;
                default:
                    console.log("Invalid command!");
            }
        }
        catch (e) {
            console.error("Unable to read", e);
        }
    }
};

runProgram();