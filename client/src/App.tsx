import { useEffect, useState } from "react";
import { List, ListItem, ListItemText, Typography } from "@mui/material";
import "./App.css";
import axios from "axios";

function App() {
  const title = "Reactivities";
  const [activities, setactivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => setactivities(response.data));
  }, []);

  return (
    <>
      <Typography variant="h3" className="app" style={{ color: "blue" }}>
        {title}
      </Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App;
