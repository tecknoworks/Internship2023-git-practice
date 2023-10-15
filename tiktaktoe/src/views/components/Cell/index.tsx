import { useState } from "react"
import "./cell.css"

type currentValue = "x" | "o" | undefined

type Props = {
    cellVal: currentValue
    turn: boolean
    onClick: (id: number) => void
    id: number
}

export default function Cell({cellVal, turn,id, onClick}:Props){

    return(
        <div className="cell-wrapper" onClick={()=>onClick(id)}>
            {cellVal === undefined && (
                <div></div>
            )}
            {cellVal === "x" && (
                <div>X</div>
            )}
            {cellVal === "o" && (
                <div>O</div>
            )}
        </div>
    )
}