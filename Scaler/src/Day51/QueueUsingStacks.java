package Day51;

import java.util.Stack;

public class QueueUsingStacks {

	static Stack<Integer> st1 = new Stack<>(), st2 =  new Stack<>();
	QueueUsingStacks(){}
	
	public static void main(String[] args) {
		push(20);
		empty();
		peek();
		pop();
		empty();
		push(30);
		peek();
		push(40);
		peek();
	}
	
    static void move(){
        while(!st1.empty()) st2.push(st1.pop());
    }
    static void push(int X){
        st1.push(X);
    }
    static int pop(){
        if(st2.empty()) move();
        return st2.pop();
    }
    static int peek(){
        if(st2.empty()) move();
        return st2.peek();
    }
    static boolean empty(){
        return st1.empty() && st2.empty();
    }

}
