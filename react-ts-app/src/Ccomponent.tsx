import React, { Component } from 'react';
interface Props {}
interface State {}

export default class Ccomponent extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items:[]
        };
    }

    componentDidMount(){
        fetch("https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail")
        .then (res => res.json())
        .then(
            (result) => {
                this.setState({
                    isLoaded: true,
                    items: result.drinks
                });
            },
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }
        )
    }

    render() {
        let error : any = this.state;
        let isLoaded : any = this.state;
        let items : any = this.state;

        // const {error, isLoaded, items} = this.state;
        if (error) {
            return <p> Error {error.message}  </p>
        } else if (!isLoaded) {
            return <p> Loading...  </p>
        } else {
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.name}>
                            {item.strDrink}
                            <img width="50" height="50" src={item.strDrinkThumb}/>
                        </li>
                    ))}
                </ul>
            )
        }
    }
}
