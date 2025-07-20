const js_template = `const js_template = {js!r};
const py_template = {py!r};
console.log(
  js_template
    .replace('{js!r}', JSON.stringify(js_template))
    .replace('{py!r}', JSON.stringify(py_template))
);
`;

const py_template = `js_template = {js!r}

py_template = {py!r}

print(
    js_template.format(js=js_template, py=py_template)
)
`;

console.log(
  py_template
    .replace('{js!r}', JSON.stringify(js_template))
    .replace('{py!r}', JSON.stringify(py_template))
);
