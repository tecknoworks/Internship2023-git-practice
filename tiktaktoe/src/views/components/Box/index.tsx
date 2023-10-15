import React, { useEffect, useState } from "react"
import Cell from "../Cell"
import handleWinner from "./handleWinner"
import "./box.css"

type currentValue = "x" | "o" | undefined

export default function Box() {
    const defaultVals = [undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined]
    const [cellCurVal, setCelCurVal] = useState<currentValue[]>(defaultVals)
    const [turn, setTurn] = useState<boolean>(true)
    const [winnerText, setwinnerText] = useState<string>("")

    useEffect(() => {
        let winner = handleWinner(cellCurVal)
        if (winner) {
            setwinnerText("Winner: " + winner);
        }
    }, [cellCurVal])

    const handleClick = (id: number) => {
        if (cellCurVal[id] === undefined && winnerText === "") {
            setTurn(!turn)
            setCelCurVal(prevState => {
                const newState = [...prevState]
                newState[id] = turn ? "x" : "o"
                return newState
            })
        }

    }

    return (
        <div className="board-wrapper">
            <span className="winner-text">
                {winnerText}
            </span>
            <div className="box-wrapper">
                <Cell id={0} cellVal={cellCurVal[0]} turn={turn} onClick={handleClick} />
                <Cell id={1} cellVal={cellCurVal[1]} turn={turn} onClick={handleClick} />
                <Cell id={2} cellVal={cellCurVal[2]} turn={turn} onClick={handleClick} />
                <Cell id={3} cellVal={cellCurVal[3]} turn={turn} onClick={handleClick} />
                <Cell id={4} cellVal={cellCurVal[4]} turn={turn} onClick={handleClick} />
                <Cell id={5} cellVal={cellCurVal[5]} turn={turn} onClick={handleClick} />
                <Cell id={6} cellVal={cellCurVal[6]} turn={turn} onClick={handleClick} />
                <Cell id={7} cellVal={cellCurVal[7]} turn={turn} onClick={handleClick} />
                <Cell id={8} cellVal={cellCurVal[8]} turn={turn} onClick={handleClick} />
            </div>
        </div>

    )
}