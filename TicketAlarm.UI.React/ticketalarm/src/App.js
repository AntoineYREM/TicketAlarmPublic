import './App.css';
import {Route, Routes, Switch , Navigate} from 'react-router-dom'
import Shows from './components/shows';
import ShowPage from './components/showPage';
import Show from './components/show';
import NotFound from './components/notFound';
import MonForm from './components/monform';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <main className='container'>
      <ToastContainer></ToastContainer>
      <h1>Hello world</h1>
      <div className='content'>
        <Routes>
          <Route path="/" Component={Shows}>AAAAAAAA</Route>
          <Route path="/bonjour/:id"  Component={ShowPage}  ></Route>
          <Route path="/bonjour"  render={(props) => <ShowPage sortBy="test" {...props}></ShowPage>}>AAAAAAAA</Route>
          <Route path="/bonjour2"   Component={ShowPage}  >AAAAAAAA</Route>
          <Route path="/monform"   Component={MonForm}  >monform</Route>
        {/* <Navigate to="/not-found" Component={NotFound}></Navigate> */}
        </Routes>
      </div>
    </main>
  );
}

export default App;
