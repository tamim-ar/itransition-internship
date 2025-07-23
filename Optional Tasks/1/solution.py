js_template = '''let py_code = {py!r};
console.log(py_code);
'''

py_code = '''js_template = {js!r}

py_code = {py!r}

print(js_template.format(py=py_code, js=js_template))
'''

print(js_template.format(py=py_code, js=js_template))
