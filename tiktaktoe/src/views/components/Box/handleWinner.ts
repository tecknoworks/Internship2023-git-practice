type currentValue = "x" | "o" | undefined

export default function handleWinner(cellVal: currentValue[]): currentValue {
    const box: number[][] = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];
    for (let i = 0; i < box.length; i++) {
        const [p1, p2, p3] = box[i];
        if (cellVal[p1] && cellVal[p1] === cellVal[p2] && cellVal[p1] === cellVal[p3]) {
            return cellVal[p1];
        }
    }

    return undefined;
}