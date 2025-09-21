
const GameInfo = ({ wins, draws, losses, currPlayer, winner }) => {
    return (
        <div className="Game-info">
            <p>Player 1: X</p>
            <p>Player 2: O</p>
            <p>Wins: {wins ?? 0}</p>
            <p>Draws: {draws ?? 0}</p>
            <p>Losses: {losses ?? 0}</p>
            <p>Current Player: {currPlayer ?? "None"}</p>
            <p>Winner: {winner ?? "None"}</p>
        </div>
    );
}

export default GameInfo;