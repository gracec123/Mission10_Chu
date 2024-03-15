import logo from './bowlinglogo.jpg';

function Header(props: any) {
  return (
    <header className="row header navbar navbar-dark bg-dark">
      <div className="col-4">
        <img src={logo} className="logo" alt="logo" width="145" height="100" />
      </div>
      <div className="col subtitle">
        <h1 className="text-white"> {props.title} </h1>
        <p className="text-white">
          Welcome to bowling database, you can find the best bowling team!
        </p>
      </div>
    </header>
  );
}

export default Header;
