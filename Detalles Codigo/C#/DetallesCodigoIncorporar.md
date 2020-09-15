### Return abreviado

```
private _provider;
```
Forma larga:

```
public string SomethingWithString(string oneString)
{
    return _provider.OneMethodWithString(oneString);
}
```
Forma abreviada:

```
public string SomethingWithString(string oneString) =>
    _provider.OneMethodWithString(oneString);
```
### Get y set personalizado

```
public string ConnectionString
        {
            get { return connectionString ?? ConnectionStringFromEnv; }
            set { connectionString = value; }
        }
```
El operdor ?? evalua si el operando izquierdo (connectionString) es null.
 - Si connectionString != null devuelve ese mismo valor.
 - Sí connectionString == null devuelve ConnectionStringFromEnv

Sería algo como:

```
if (connectionString != null)
{
    return connectionString;
}
else if(connectionString == null)
{
    return ConnectionStringFromEnv;
}
```

Nota: Sí connectionString no es null no evaluará el operando derecho (ConnectionStringFromEnv).
```
a ?? b ?? c
d ??= e ??= f
```
Se evalúa como:
```
a ?? (b ?? c)
d ??= (e ??= f)
```

### Métodos con argumentos personalizados

De primeras algún argumento debe ser null de entrada para que sea válido. O en un estado determinado como queramos sí es booleano.

```
public void SomeMethod(string argument1, string argument2 = null, bool boolArguent = false)
{
    // Do something with arguments
}
```
### SingleOrDefault()

Retorna un elemento sólo o el predetermiando (cual es?). Para objetos list o DbSet entre otros.

### Los Forech

Existen dos formas de hacerlo, la forma más evidente;

```
foreach (var coordenada in _listaCoordenadasIII)
            {
                if (coordenada.YaUtilizada == false) 
                {
                    Mu newMu = new Mu(NuevaCadenaReglaTres(coordenada, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);
                }
            }
```

Y la forma de utilizar un método:

```
_listaCoordenadasIII.ForEach(x =>
            {
                if (x.YaUtilizada == false)
                {
                    Mu newMu = new Mu(NuevaCadenaReglaTres(x, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);

                    _listaCoordenadasIII.Remove(x);
                }
            });
```

El punto positivo de utilizar ésta forma es que no utiliza un objeto de tipo Enumerator para recorrerlo. Eso nos permite utilizar el método Remove() sí queremos utilizarlo.

### Clonar listas de manera elegante: AddRange()
```
unaLista.AddRange(otraLista);
```

Permite copiar de una lista a otra los objetos de su interior. Se puede tambien hacer copiar parametrizadas.

```
List<string> lstNew = lstTest.GetRange(0, 3);
```

En éste caso copiando los primeros 3 elementos.