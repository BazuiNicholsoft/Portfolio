import React from 'react';
import Label from '../../atoms/Label/Label';
import './GameInfo.css';
import labelStyles from '../../atoms/Label/Label.module.css';
const GameInfo = ({ wins, draws, losses, currPlayer, winner }) => {
    return (
        <div className="GameInfoContainer">
            <div className="GameInfoBackground">
                <div className="LabelRow">
                    <Label text="Player 1: " className={labelStyles.label} /> <Label text="X" className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Player 2: " className={labelStyles.label} /> <Label text="O" className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Wins: " className={labelStyles.label} /> <Label text={wins ?? 0} className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Draws: " className={labelStyles.label} /> <Label text={draws ?? 0} className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Losses: " className={labelStyles.label} /> <Label text={losses ?? 0} className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Current Player: " className={labelStyles.label} /> <Label text={currPlayer ?? "None"} className={labelStyles.value} />
                </div>
                <div className="LabelRow">
                    <Label text="Winner: " className={labelStyles.label} /> <Label text={winner ?? "None"} className={labelStyles.value} />
                </div>
            </div>
        </div>
    );
}

export default GameInfo;