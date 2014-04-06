var dataset = [
              {
                  "ChipType": "AAddB"
              },
              {
                  "ChipType": "ADividedByB"
              },
              {
                  "ChipType": "AMinusB"
              }
];

d3.select("body").selectAll("p")
    .data(dataset)
    .enter()
    .append("p")
    .text(function (data) { return data.ChipType; })
    .style("color", "yellow");