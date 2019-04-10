const baseState = {
    range: {
        from: null,
        to: null
    }
};

function analytics() {
    return (state = baseState, action) => {
        switch (action.type) {
            case "UPDATE_EXAMPLE": {
                return { ...state, range: action.payload };
            }
            default:
                return state;
        }
    };
}

export default analytics;
